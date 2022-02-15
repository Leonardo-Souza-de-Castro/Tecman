import axios from "axios";

export const LerConteudo = async (formData) => {

    let resultado

        await axios({
        method:"post",
        url:"https://ocr-tecman.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data: formData,
        headers: {"Content-type": "multipart/formdata", "Ocp-Apim-Subscription-Key": "76791642035d43e59c29f41dadfa04a6"}
    })
    .then(response => {
        console.log(response)
        resultado = LerJSON(response.data)
    })
    .catch(erro => console.log(erro))
    return resultado
}

export const LerJSON = (obj) =>{

    let resultado

    obj.regions.forEach(regions => {
        regions.lines.forEach(lines => {
            lines.words.forEach(words => {
                if (words.text[0] === "1" && words.text[1] === "2") {
                    resultado = words.text
                }
            });
        });
    });

    return resultado
}