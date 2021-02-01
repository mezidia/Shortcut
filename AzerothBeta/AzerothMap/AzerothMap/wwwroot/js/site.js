const img = document.getElementById('image');
const canvasjs = document.getElementById('canvas');
const ctx = canvasjs.getContext('2d');

canvas.width = 400
canvas.height = 300;

img.onload = function () {
    ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
}