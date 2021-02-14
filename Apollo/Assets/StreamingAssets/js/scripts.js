function sendUpdateRequest() {
	const xhr = new XMLHttpRequest();
	xhr.open("GET", location.href + "?_=" + new Date().getTime());
	xhr.setRequestHeader("update", "true");

	xhr.onload = () => {
		document.open();
		document.write(xhr.response);
		document.close();
	}
	xhr.send();
}
