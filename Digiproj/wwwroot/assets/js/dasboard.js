var ctx = document.getElementById("barChartDemo").getContext('2d');
var myChart = new Chart(ctx, {
	type: 'bar',
	data: {
		labels: ["NS", "IP", "Done"],
		datasets: [{
			label: '# of total',
			data: [12, 19, 3],
			backgroundColor: [
				'rgba(255, 99, 132, 0.2)',
				'rgba(255, 206, 86, 0.2)',
				'rgba(75, 192, 192, 0.2)'
			],
			borderColor: [
				'rgba(255,99,132,1)',
				'rgba(255, 206, 86, 1)',
				'rgba(75, 192, 192, 1)'
			],
			borderWidth: 1
		}]
	},
	options: {
		scales: {
			yAxes: [{
				ticks: {
					beginAtZero: true
				}
			}]
		},
		title: {
			display: true,
			text: 'Chart'
		}
	}
});


var ctp = document.getElementById("pieChartDemo").getContext('2d');
const mixedChart = new Chart(ctp, {
	data: {
		datasets: [{
			type: 'pie',
			label: '# of total',
			data: [10, 20, 30],
			backgroundColor: [
				'rgba(255, 99, 132, 0.2)',
				'rgba(255, 206, 86, 0.2)',
				'rgba(75, 192, 192, 0.2)'
			],
		}],
		labels: [
			'NS',
			'IP',
			'Done'
		]
	}
});