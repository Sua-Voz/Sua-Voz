const modal = document.querySelector('.modal-denuncia');
const closeBtn = document.querySelector('button#fechar');
const openBtn = document.querySelector('button#fazer-denuncia');
const form = document.querySelector('form.form-denuncia');
const sectionDenuncias = document.querySelector('section.denuncias');
const textarea = document.querySelector('textarea');
const divContainer = document.querySelector('.area-denuncia');
const header = document.querySelector('.navbar');

const resetTextArea = () => (textarea.value = '');

const focusTextArea = () => textarea.focus();

const eraseFooterAndHeader = () => {
	header.classList.toggle('erase');
};

closeBtn.onclick = function () {
	eraseFooterAndHeader();
};

openBtn.onclick = function () {
	eraseFooterAndHeader();
	focusTextArea();
};

form.onsubmit = function (event) {
	event.preventDefault();
	resetTextArea();
	eraseFooterAndHeader();
};
