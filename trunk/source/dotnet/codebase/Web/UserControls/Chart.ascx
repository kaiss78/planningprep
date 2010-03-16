<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chart.ascx.cs" Inherits="UserControls_Chart" %>
<script type="text/javascript" src="http://www.google.com/jsapi"></script>
    <script type="text/javascript">
      google.load("visualization", "1", {packages:["piechart"]});
      google.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Task');
        data.addColumn('number', 'Hours per Day');
        data.addRows(4);
        data.setValue(0, 0, 'Answer A');
        data.setValue(0, 1, <%=PercentageOfA %>);
        data.setValue(1, 0, 'Answer B');
        data.setValue(1, 1, <%=PercentageOfB %>);
        data.setValue(2, 0, 'Answer C');
        data.setValue(2, 1, <%=PercentageOfC %>);
        data.setValue(3, 0, 'Answer D');
        data.setValue(3, 1, <%=PercentageOfD %>);

        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        chart.draw(data, {width: 400, height: 240, is3D: true, title: '*Based on <%=TotalResponse.ToString()%> responses'});
      }
    </script>
<div id="chart_div"></div>

