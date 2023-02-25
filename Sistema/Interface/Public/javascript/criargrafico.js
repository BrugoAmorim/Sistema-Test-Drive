
export const createConfigsPizza = (data) => {
  
    // create the chart
    const chart = anychart.pie();

    // add the data
    chart.data(data);

    chart.legend().position('right');
    chart.legend().itemsLayout('vertical');
    chart.legend().fontSize('1.2em');

    // display the chart in the container
    chart.container('grafico-pizza');
    chart.draw();
}
