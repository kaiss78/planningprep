using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Web.Services.Protocols;
using System.Xml.Schema;
using Microsoft.CSharp;
using App.Core.Extensions;

namespace App.Core.WebServices
{
    /// <summary>
    /// Used to make Web Service Proxy Classes from any Web Service WSDL definition.
    /// Definitions:
    /// IContract is the Contract of Web Service be consumed.
    /// Sample Use:
    /// WebServiceProxyFactory&lt;IContract&gt; factory = new WebServiceProxyFactory&lt;IContract&gt;( "http://localhost:2008/TestService/TestProxy.asmx?WSDL" ) { UseGenericList = true };
    /// IContract proxy = factory.Build( );
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WebServiceProxyFactory<T> where T : class
    {
        #region Constants

        private const string ProxyNameSpace = "SimpleFramework.DynamicProxyFactory.Proxies";
        private const string ListFullClassName = "System.Collections.Generic.List<{0}>";

        #endregion

        #region Private Vars

        private readonly Uri _wsdlLocation;

        private readonly DiscoveryProtocol _protocolName = DiscoveryProtocol.Soap;

        private readonly Type _serviceContract;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceProxyFactory&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="wsdlLocation">The WSDL location.</param>
        public WebServiceProxyFactory( string wsdlLocation ) : this( new Uri( wsdlLocation ), DiscoveryProtocol.Soap ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceProxyFactory&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="wsdlLocation">The WSDL location.</param>
        /// <param name="protocolName">Name of the protocol.</param>
        public WebServiceProxyFactory( string wsdlLocation, DiscoveryProtocol protocolName ) : this( new Uri( wsdlLocation ), protocolName ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceProxyFactory&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="wsdlLocation">The WSDL location.</param>
        public WebServiceProxyFactory( Uri wsdlLocation ) : this( wsdlLocation, DiscoveryProtocol.Soap ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServiceProxyFactory&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="wsdlLocation">The WSDL location.</param>
        /// <param name="protocolName">Name of the protocol.</param>
        public WebServiceProxyFactory( Uri wsdlLocation, DiscoveryProtocol protocolName )
        {
            ProxiesGenerated = new Dictionary<string, object>();
            _wsdlLocation = wsdlLocation;
            _protocolName = protocolName;
            _serviceContract = typeof( T );
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [use generic list].
        /// </summary>
        /// <value><c>true</c> if [use generic list]; otherwise, <c>false</c>.</value>
        public bool UseGenericList { get; set; }

        /// <summary>
        /// Gets the proxies that have been generated.
        /// </summary>
        /// <value>The proxies generated.</value>
        public Dictionary<string, object> ProxiesGenerated { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds this proxy assembly.
        /// </summary>
        /// <returns></returns>
        public T Build( )
        {
            ServiceDescriptionImporter importer = null;

            try
            {
                if (_wsdlLocation.IsNull())
                {
                    throw new ArgumentNullException("WsdlLocation", "The argument 'WsdlLocation' can't be null");
                }
                importer = new ServiceDescriptionImporter {ProtocolName = _protocolName.ToString()};

                //Get WSDL
                DiscoverService( importer );

                //Proxy source code generation
                Assembly assembly;

                using ( CSharpCodeProvider codeProvider = new CSharpCodeProvider() )
                {
                    assembly = GenerateProxyAssembly( codeProvider, GenerateProxySourceCode( importer, codeProvider ) );
                }

                return Activator.CreateInstance( assembly.GetTypes()[ 0 ] ) as T;
            }
            finally
            {
                //Clean up resources
                if ( importer.IsNotNull() )
                {
                    importer = null;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Discovers the service.
        /// </summary>
        /// <param name="importer">The importer.</param>
        private void DiscoverService( ServiceDescriptionImporter importer )
        {
            using ( DiscoveryClientProtocol discoClient = new DiscoveryClientProtocol( ) )
            {
                discoClient.DiscoverAny( _wsdlLocation.ToString( ) );
                discoClient.ResolveAll( );

                foreach ( object value in discoClient.Documents.Values )
                {
                    if (value is ServiceDescription)
                    {
                        importer.AddServiceDescription((ServiceDescription) value, null, null);
                    }
                    if (value is XmlSchema)
                    {
                        importer.Schemas.Add((XmlSchema) value);
                    }
                }
            }
        }

        /// <summary>
        /// Generates the proxy source code.
        /// </summary>
        /// <param name="importer">The importer.</param>
        /// <param name="codeProvider">The code provider.</param>
        /// <returns></returns>
        private string GenerateProxySourceCode( ServiceDescriptionImporter importer, CSharpCodeProvider codeProvider )
        {
            CodeNamespace mainNamespace = new CodeNamespace( ProxyNameSpace );

            importer.Import( mainNamespace, null );

            if ( UseGenericList )
                ChangeArrayToGenericList( mainNamespace );

            AddImports( mainNamespace );

            CodeTypeDeclaration[] temp = new CodeTypeDeclaration[ mainNamespace.Types.Count ];
            mainNamespace.Types.CopyTo( temp, 0 );
            foreach ( CodeTypeDeclaration declarationType in temp )
            {
                if ( ( declarationType.BaseTypes.Count > 0 ) && ( declarationType.BaseTypes[ 0 ].BaseType == typeof( SoapHttpClientProtocol ).FullName ) )
                    declarationType.BaseTypes.Add( _serviceContract );
                else
                    mainNamespace.Types.Remove( declarationType );
            }

            //Clean up resources
            temp = null;

            //Proxy source code generation
            StringBuilder sourceCode = new StringBuilder( );
            string ret;

            using ( StringWriter sw = new StringWriter( sourceCode, CultureInfo.CurrentCulture ) )
            {
                codeProvider.GenerateCodeFromNamespace( mainNamespace, sw, null );
                ret = sourceCode.ToString( );
                sw.Close( );
            }

            //Clean up resources
            mainNamespace = null;
            sourceCode = null;

            return ret;
        }

        /// <summary>
        /// Changes the array to generic list.
        /// </summary>
        /// <param name="codeNamespace">The code namespace.</param>
        private void ChangeArrayToGenericList( CodeNamespace codeNamespace )
        {
            CodeTypeDeclaration[] temp = new CodeTypeDeclaration[ codeNamespace.Types.Count ];
            codeNamespace.Types.CopyTo( temp, 0 );
            foreach (CodeMemberMethod methodMember in temp.SelectMany(type => type.Members.OfType<CodeMemberMethod>()))
            {
                foreach (CodeParameterDeclarationExpression paremeter in
                    methodMember.Parameters.Cast<CodeParameterDeclarationExpression>().Where(paremeter => paremeter.Type.ArrayElementType != null))
                {
                    paremeter.Type = new CodeTypeReference( String.Format( CultureInfo.InvariantCulture, ListFullClassName, paremeter.Type.ArrayElementType.BaseType ) );
                }

                if ( methodMember.ReturnType.ArrayElementType != null )
                {
                    string listGenericType = String.Format( CultureInfo.InvariantCulture, ListFullClassName, methodMember.ReturnType.ArrayElementType.BaseType );

                    methodMember.ReturnType = new CodeTypeReference( listGenericType );

                    CodeMethodReturnStatement returnStatement = null;
                    foreach ( CodeStatement code in methodMember.Statements )
                    {
                        returnStatement = code as CodeMethodReturnStatement;
                        if (returnStatement.IsNotNull())
                            break;
                    }

                    if (returnStatement.IsNotNull())
                    {
                        methodMember.Statements.Remove( returnStatement );
                        methodMember.Statements.Add( new CodeMethodReturnStatement( new CodeArgumentReferenceExpression( String.Format( CultureInfo.InvariantCulture, "({0})results[0]", listGenericType ) ) ) );
                    }
                }
            }
        }

        /// <summary>
        /// Adds the imports.
        /// </summary>
        /// <param name="codeNamespace">The code namespace.</param>
        private void AddImports( CodeNamespace codeNamespace )
        {
            MethodInfo[] methods = _serviceContract.GetMethods( );
            foreach ( MethodInfo method in methods )
            {
                AddImport( codeNamespace, method.ReturnType );

                foreach ( ParameterInfo parameter in method.GetParameters( ) )
                    AddImport( codeNamespace, parameter.ParameterType );
            }
        }

        /// <summary>
        /// Adds the import.
        /// </summary>
        /// <param name="codeNamespace">The code namespace.</param>
        /// <param name="type">The type.</param>
        private void AddImport( CodeNamespace codeNamespace, Type type )
        {
            if ( !type.IsPrimitive )
                codeNamespace.Imports.Add( new CodeNamespaceImport( type.Namespace ) );
        }

        /// <summary>
        /// Generates the proxy assembly.
        /// </summary>
        /// <param name="csharpCodeProvider">The csharp code provider.</param>
        /// <param name="proxyCode">The proxy code.</param>
        /// <returns></returns>
        private Assembly GenerateProxyAssembly( CSharpCodeProvider csharpCodeProvider, string proxyCode )
        {
            CompilerResults complierResults = null;
            CompilerParameters complierParameters = null;
            try
            {
                //Assembly compilation
                string location = String.Empty;

                if (HttpContext.Current.IsNotNull())
                {
                    location = HttpContext.Current.Server.MapPath( "." );
                    location += @"\bin\"; // TODO: Change to work from configuration file.
                }

                complierParameters = new CompilerParameters();

                complierParameters.ReferencedAssemblies.Add( "System.dll" );
                complierParameters.ReferencedAssemblies.Add( "System.Data.dll" );
                complierParameters.ReferencedAssemblies.Add( "System.Xml.dll" );
                complierParameters.ReferencedAssemblies.Add( "System.Web.dll" );
                complierParameters.ReferencedAssemblies.Add( "System.Web.Services.dll" );
                complierParameters.ReferencedAssemblies.Add( Assembly.GetExecutingAssembly().Location );

                GetReferencedAssemblies( _serviceContract.Assembly, complierParameters );

                complierParameters.GenerateExecutable = false;
                complierParameters.GenerateInMemory = false;
                complierParameters.IncludeDebugInformation = false;
                complierParameters.TempFiles = new TempFileCollection((!location.IsNullOrEmpty()) ? location : Path.GetTempPath());

                complierResults = csharpCodeProvider.CompileAssemblyFromSource( complierParameters, proxyCode );

                if ( complierResults.Errors.Count > 0 )
                {
                    StringBuilder sb = new StringBuilder();
                    for ( int i = 0; i < complierResults.Errors.Count; i++ )
                    {
                        sb.Append( Environment.NewLine );
                        sb.Append( "'" );
                        sb.Append( String.Format( CultureInfo.InvariantCulture, "{0} - {1}", complierResults.Errors[ i ].ErrorNumber, complierResults.Errors[ i ].ErrorText ) );
                        sb.Append( "'" );
                    }

                    throw new ApplicationException( String.Format( CultureInfo.InvariantCulture, "Building web service proxy has failed with {0} errors. Errors:{1}", complierResults.Errors.Count, sb.ToString() ) );
                }

                Assembly ret = complierResults.CompiledAssembly;
                return ret;
            }
            catch ( Exception ex )
            {
                Debugger.Log( 1, "Exceptions", ex.Message );
                throw;
            }
            finally
            {
                //Clean up resources
                if(complierResults.IsNotNull()) complierResults = null;
                if (complierResults.IsNotNull()) complierParameters = null;
            }
        }

        /// <summary>
        /// Gets the referenced assemblies.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="parameters">The parameters.</param>
        private static void GetReferencedAssemblies( Assembly assembly, CompilerParameters parameters )
        {
            if ( !parameters.ReferencedAssemblies.Contains( assembly.Location ) )
            {
                string location = Path.GetFileName( assembly.Location );
                if ( !parameters.ReferencedAssemblies.Contains( location ) )
                {
                    parameters.ReferencedAssemblies.Add( assembly.Location );
                    foreach ( AssemblyName referencedAssembly in assembly.GetReferencedAssemblies( ) )
                        GetReferencedAssemblies( Assembly.Load( referencedAssembly.FullName ), parameters );
                }
            }
        }

        #endregion
    }
}