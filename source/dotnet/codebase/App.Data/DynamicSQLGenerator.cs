#region History

/* --------------------------------------------------------------------------------
 * Client Name: NQF
 * Project Name: OPLM
 * Module: OPLM.DAL
 * Name: DynamicSQLGenerator
 * Purpose: An utility class which generates dynamic sql
 *                   
 * Author: MHA
 * Language: C# SDK version 3.5
 * --------------------------------------------------------------------------------
 * Change History:
 * version: 1.0    MHA  10/04/09
 * Description: Initial Development
 * -------------------------------------------------------------------------------- 
 * version: 1.1    MR  10/05/09
 * Description: Create overload method for GetUserSearchSQL method to support inactive and roles
 * -------------------------------------------------------------------------------- */

#endregion

using System;
using System.Text;

namespace App.Data
{
    /// <summary>
    /// An utility class which generates dynamic sql
    /// </summary>
    public class DynamicSQLGenerator
    {
        #region Constructor

        public DynamicSQLGenerator()
        {
            
        }

        #endregion
    
        #region Method
        /// <summary>
        /// Generate dynamic user search criteria depending on the input provided
        /// </summary>
        /// <param name="keyword">keyword to search</param>
        /// <param name="inactive">include inactive user or not</param>
        /// <param name="roles">comma separated role ids</param>
        /// <param name="sortBy">sort by filed name</param>
        /// <param name="sortOrder">sord direction</param>
        /// <returns></returns>
        public string GetUserSearchSQL(string keyword, bool inactive, string roles, string sortBy, string sortOrder)
        {
            StringBuilder dynamicSQL = new StringBuilder();
            StringBuilder dynamicSQLLogic = new StringBuilder();
            bool criteriaProvided = false;
            char[] splitter = { ' ' };
            string[] keywords = string.IsNullOrEmpty(keyword) ? null : keyword.Split(splitter);

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "UserName";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = " ASC";
            }

            ///Add list of columns to get the result from user search
            dynamicSQL.AppendFormat(@"
                               SELECT Usr.UserID OPLMUserID, 
                                      Usr.UserName UserName, 
                                      Usr.LastName LastName,
                                      Usr.FirstName FirstName,                                        
                                      Usr.Email EMAIL,  
                                      Usr.Title Title, 
                                      Usr.Active STATUS,
                                      Role.RoleName RoleName,
                                      Role.RoleID,
                                      Usr.OPLMIMISUserID OPLMIMISUserID,
                                      row_number() over (ORDER BY {0}  {1})  rowIndex 
                               FROM ( ", sortBy, sortOrder);

            //Add query for keyword search
            if (keywords != null && keywords.Length > 0)
            {
                criteriaProvided = true;
                dynamicSQL.Append(@"
                                SELECT 
                                        UserID
                                FROM  
                                        OPLM_USER
                                WHERE ");

                foreach (string key in keywords)
                {
                    if (dynamicSQLLogic.Length != 0)
                        dynamicSQLLogic.Append("AND ");

                    dynamicSQLLogic.AppendFormat("Contains(OPLM_USER.*,' \"{0}*\" ') ", key.Replace("'","''"));
                }
                dynamicSQL.Append(dynamicSQLLogic.ToString());               
            }

            //If inactive user will not be considered for search
            if (!inactive)
            {
                if (criteriaProvided)
                {
                    dynamicSQL.Append(" INTERSECT ");
                }
                else
                {
                    criteriaProvided = true;
                }

                dynamicSQL.AppendFormat(@"
                               SELECT 
                                        UserID
                               FROM  
                                        OPLM_USER
                               WHERE 
                                        Active = 1 ");
            }

            //Add query for selected roles
            if (roles != string.Empty)
            {
                if (criteriaProvided)
                {
                    dynamicSQL.Append(" INTERSECT ");
                }
                else
                {
                    criteriaProvided = true;
                }
                dynamicSQL.Append(" ( ");
                
                //Split role ids from individual role based query generation
                string[] roleIds = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                bool firstRole = true;
                foreach (string roleId in roleIds)
                {
                    if (!firstRole)
                        dynamicSQL.Append(" UNION ");
                    dynamicSQL.AppendFormat(@"
                               SELECT 
                                        Usr.UserID
                               FROM  
                                        OPLM_USER Usr
                               INNER JOIN 
                                        OPLM_USER_ROLE USER_ROLE ON
                                        Usr.UserID = USER_ROLE.UserID                                 
                               WHERE USER_ROLE.RoleId = {0} 
                                ", roleId);

                    firstRole = false;
                }

                dynamicSQL.Append(" ) ");
            }

            //If no user criteria provided for search 
            if (!criteriaProvided)
                dynamicSQL.Append(" SELECT UserID FROM OPLM_USER");

            dynamicSQL.Append(@" ) AS result
                                    INNER JOIN OPLM_USER Usr 
                                        ON result.UserID = Usr.UserID
                                    INNER JOIN OPLM_USER_ROLE USER_ROLE 
                                        ON Usr.UserID = USER_ROLE.UserID
                                    INNER JOIN OPLM_ROLE ROLE 
                                        ON ROLE.RoleID = USER_ROLE.RoleID ");

            return dynamicSQL.ToString();
        }

        /// <summary>
        /// Generate dynamic user search criteria depending on the input provided to add user as Staff
        /// </summary>
        /// <param name="keyword">keyword to search</param>
        /// <param name="inactive">include inactive user or not</param>
        /// <param name="roles">comma separated role ids</param>
        /// <param name="sortBy">sort by filed name</param>
        /// <param name="sortOrder">sord direction</param>
        /// <returns></returns>
        public string GetUserSearchSQLToAddAsStaff(string keyword, long projectID, bool inactive, string roles, string sortBy, string sortOrder)
        {
            StringBuilder dynamicSQL = new StringBuilder();
            StringBuilder dynamicSQLLogic = new StringBuilder();
            bool criteriaProvided = false;
            char[] splitter = { ' ' };
            string[] keywords = string.IsNullOrEmpty(keyword) ? null : keyword.Split(splitter);

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "UserName";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = " ASC";
            }

            //Add list of columns to get the result from user search
            dynamicSQL.AppendFormat(@"
                               SELECT Usr.UserID OPLMUserID, 
                                      Usr.UserName UserName, 
                                      Usr.LastName LastName,
                                      Usr.FirstName FirstName,                                        
                                      Usr.Email EMAIL,  
                                      Usr.Title Title, 
                                      Usr.Active STATUS,
                                      Role.RoleName RoleName,
                                      Role.RoleID,
                                      Usr.OPLMIMISUserID OPLMIMISUserID,
                                      row_number() over (ORDER BY {0}  {1})  rowIndex 
                               FROM ( ", sortBy, sortOrder);

            //Add query for keyword search
            if (keywords != null && keywords.Length > 0)
            {
                criteriaProvided = true;
                dynamicSQL.Append(@"
                                SELECT 
                                        UserID
                                FROM  
                                        OPLM_USER
                                WHERE ");

                foreach (string key in keywords)
                {
                    if (dynamicSQLLogic.Length != 0)
                        dynamicSQLLogic.Append("OR ");

                    if (keyword.StartsWith("\"") && keyword.EndsWith("\""))
                    {
                        dynamicSQLLogic.AppendFormat("Contains(OPLM_USER.*,' \"{0}\" ') ", keyword.Replace("'", "''").Replace("\"", ""));
                    }
                    else
                    {
                        dynamicSQLLogic.AppendFormat("Contains(OPLM_USER.*,' \"{0}*\" ') ", key.Replace("'", "''").Replace("\"", ""));
                    }
                    
                }
                dynamicSQL.Append(dynamicSQLLogic.ToString());
            }

            //If inactive user will not be considered for search
            if (!inactive)
            {
                if (criteriaProvided)
                {
                    dynamicSQL.Append(" INTERSECT ");
                }
                else
                {
                    criteriaProvided = true;
                }

                dynamicSQL.AppendFormat(@"
                               SELECT 
                                        UserID
                               FROM  
                                        OPLM_USER
                               WHERE 
                                        Active = 1 ");
            }

            //Add query for selected roles
            if (roles != string.Empty)
            {
                if (criteriaProvided)
                {
                    dynamicSQL.Append(" INTERSECT ");
                }
                else
                {
                    criteriaProvided = true;
                }
                dynamicSQL.Append(" ( ");

                //Split role ids from individual role based query generation
                string[] roleIds = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                bool firstRole = true;
                foreach (string roleId in roleIds)
                {
                    if (!firstRole)
                        dynamicSQL.Append(" UNION ");
                    dynamicSQL.AppendFormat(@"
                               SELECT 
                                        Usr.UserID
                               FROM  
                                        OPLM_USER Usr
                               INNER JOIN 
                                        OPLM_USER_ROLE USER_ROLE ON
                                        Usr.UserID = USER_ROLE.UserID                                 
                               WHERE USER_ROLE.RoleId = {0} 
                                ", roleId);

                    firstRole = false;
                }

                dynamicSQL.Append(" ) ");
            }

            //If no user criteria provided for search 
            if (!criteriaProvided)
                dynamicSQL.Append(" SELECT UserID FROM OPLM_USER");

            dynamicSQL.Append(@" ) AS result
                                    INNER JOIN OPLM_USER Usr 
                                        ON result.UserID = Usr.UserID
                                    INNER JOIN OPLM_USER_ROLE USER_ROLE 
                                        ON Usr.UserID = USER_ROLE.UserID
                                    INNER JOIN OPLM_ROLE ROLE 
                                        ON ROLE.RoleID = USER_ROLE.RoleID ");

            //dynamicSQL.AppendFormat(@"AND Usr.UserID NOT IN (SELECT UserID FROM OPLM_PROJECT_STAFF_MEMBER WHERE ProjectID = {0})", projectID); 

            return dynamicSQL.ToString();
        }


        public string GetProjectSearchSQL(string keyword)
        {
            StringBuilder dynamicSQL = new StringBuilder();
            StringBuilder dynamicSQLLogic = new StringBuilder();
            
            char[] splitter = { ' ' };
            string[] keywords = string.IsNullOrEmpty(keyword) ? null : keyword.Split(splitter);

            //Add query for keyword search
            if (keywords != null && keywords.Length > 0)
            {
                dynamicSQL.Append(@"WHERE (");

                foreach (string key in keywords)
                {
                    if (dynamicSQLLogic.Length != 0)
                        dynamicSQLLogic.Append("OR ");

                    if (keyword.StartsWith("\"") && keyword.EndsWith("\""))
                    {
                        dynamicSQLLogic.AppendFormat("Contains(SD.ShortDescription,' \"{0}\" ') ", keyword.Replace("'", "''").Replace("\"", ""));
                        dynamicSQLLogic.AppendFormat("OR Contains(PD.ShortName,' \"{0}\" ') ", keyword.Replace("'", "''").Replace("\"", ""));
                    }
                    else
                    {
                        dynamicSQLLogic.AppendFormat("Contains(SD.ShortDescription,' \"{0}*\" ') ", key.Replace("'", "''").Replace("\"", ""));
                        dynamicSQLLogic.AppendFormat("OR Contains(PD.ShortName,' \"{0}*\" ') ", key.Replace("'", "''").Replace("\"", ""));
                    }
                }
                dynamicSQL.Append(dynamicSQLLogic.ToString());
                dynamicSQL.Append(")");
            }

            return dynamicSQL.ToString();
        }
        #endregion
    }
}


