/*function resimdegis(_resimnum){
    var resimler = ['https://images.hdqwalls.com/wallpapers/anime-night-scenery-8r.jpg'];
    var resim = document.body.style.backgroundImage;
    var yeniresimnum = Math.floor(Math.random()*resimler.length);
    document.body.style.backgroundImage = 'url('+resimler[yeniresimnum]+')';
}
window.onload=resimdegis;
*/

function google_arama()
{
    window.location = "index.php" + encodeURIComponent(document.getElementById("q").value);
}

