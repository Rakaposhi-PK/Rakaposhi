//HOSTED FUNCTIONS MULTIPLE CHARTS

// Load Charts and the corechart and barchart packages.
google.charts.load('current', {'packages':['corechart']});

// Draw the pie chart and bar chart when Charts is loaded.
google.charts.setOnLoadCallback(drawChart);

function drawChart() {

  var data = new google.visualization.DataTable();
  data.addColumn('string', 'Topping');
  data.addColumn('number', 'Slices');
  data.addRows([
    ['Jan', 3],
    ['Feb', 1],
    ['March', 1],
    ['April', 1],
    ['May', 2]
  ]);

  var piechart_options = {title:'Hosted Functions',
                 width:400,
                 height:300};
  var piechart = new google.visualization.PieChart(document.getElementById('piechart_div1'));
  piechart.draw(data, piechart_options);

  var barchart_options = {title:'Hosted Functions',
                 width:350,
                 height:250,
                 legend: 'none'};
  var barchart = new google.visualization.AreaChart(document.getElementById('barchart_div1'));
  barchart.draw(data, barchart_options);
}
