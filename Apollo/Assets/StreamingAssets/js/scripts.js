function sendUpdateRequest() {
	const xhr = new XMLHttpRequest();
	xhr.open("GET", "http://" + location.host + location.pathname);
	xhr.setRequestHeader("update", "true");

	xhr.onload = () => {
		document.open();
		document.write(xhr.response);
		document.close();
	}
	xhr.send();
}
