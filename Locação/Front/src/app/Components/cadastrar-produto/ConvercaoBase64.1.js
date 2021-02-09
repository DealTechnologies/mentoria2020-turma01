 function ConvercaoBase64() {

    converterImgParaBase64(element); {
        var file = element.files;
        if (file.length > 0) {
            var fileToLoad = file[0];
            var fileReader = new FileReader();
            fileReader.onload = function (fileLoadedEvent) {
                var srcData = fileLoadedEvent.target.result; // <--- data: base64
                imprimirImgNaTela(srcData);
                console.log(srcData);
            };
            fileReader.readAsDataURL(fileToLoad);
        }
    }

    imprimirImgNaTela(img); {
        var newImage = document.createElement('img');
        newImage.src = img;

        document.getElementById("imgTest").innerHTML = newImage.outerHTML;
    }
}
export default ConvercaoBase64;