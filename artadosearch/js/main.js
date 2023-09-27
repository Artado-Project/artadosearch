/*function resimdegis(_resimnum){
    var resimler = ['https://images.hdqwalls.com/wallpapers/anime-night-scenery-8r.jpg'];
    var resim = document.body.style.backgroundImage;
    var yeniresimnum = Math.floor(Math.random()*resimler.length);
    document.body.style.backgroundImage = 'url('+resimler[yeniresimnum]+')';
}
window.onload=resimdegis;
*/

function Google_Search() //Edited by LinuxUsersLinuxMint. Change made: google_search has been changed to Google_search.
{
    window.location = "index.php" + encodeURIComponent(document.getElementById("q").value);
}