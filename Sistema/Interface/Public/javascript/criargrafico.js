
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

export const createConfigsBars = (data) => {
    
    const chart = anychart.bar();

    // create a bar series and set the data
    const series = chart.bar(data);

    // set the padding between bar groups
    chart.barGroupsPadding(0);

    // set the titles of the axes
    chart.title("Clientes com o maior número de agendamentos");

    // set the container id
    chart.container("grafico");

    // initiate drawing the chart
    chart.draw();

}