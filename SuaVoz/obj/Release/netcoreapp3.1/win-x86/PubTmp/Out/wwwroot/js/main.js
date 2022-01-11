const counters = document.querySelectorAll('.conquistas__card-number');

counters.forEach(counter => {
	counter.innerText = '0';
	const updateCounter = () => {
		const target = +counter.getAttribute('data-target');
		// console.log(typeof target, target);
		const c = +counter.innerText;
		const increment = target / 100;
		// console.log(increment);

		if (c < target) {
			counter.innerText = `${Math.ceil(c + increment)}`;
			setTimeout(updateCounter, 1);
		}
	};
	updateCounter();
});
