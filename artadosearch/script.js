/*
		Designed by: Eienwq
*/

const { to, set } = gsap;

document.querySelectorAll('.loading').forEach(loading => {
    loading.count = 0
    let lines = to(loading, {
        keyframes: [{
            '--line-top-x': '-100%',
            '--line-bottom-x': '-200%',
            onComplete() {
                set(loading, {
                    '--line-top-x': '200%',
                    '--line-bottom-x': '100%',
                })
            }
        }, {
            '--line-top-x': '0%',
            '--line-bottom-x': '0%'
        }],
        duration: 1,
        repeat: -1
    })

    const keyboard = document.querySelector('#keyboard')
    const arrowUp = keyboard.querySelector('.up')
    const arrowLeft = keyboard.querySelector('.left')
    const arrowRight = keyboard.querySelector('.right')
    const arrowDown = keyboard.querySelector('.down')
    const spanHidden = keyboard.querySelector('span')

    document.body.onkeyup = e => {
        if(e.keyCode == 32 || e.keyCode == 38) {
            jump(loading, lines)
            arrowUp.classList.add('pressed')
            setTimeout(() => arrowUp.classList.remove('pressed'), 400)
        }
        if(e.keyCode == 40 || e.keyCode == 39 || e.keyCode == 37) {
            if(!loading.ouch) {
                reset(loading, lines)
            }
            keyboard.querySelector('.pressed').classList.remove('pressed')
        }
        if(loading.ouch && (e.keyCode == 32 || e.keyCode == 38)) {
            loading.ouch = false
            reset(loading, lines)
        }
    }

    document.body.onkeydown = e => {
        if(e.keyCode == 39){
            fast(loading, lines)
            arrowRight.classList.add('pressed')
        }
        if(e.keyCode == 40){
            down(loading, lines)
            arrowDown.classList.add('pressed')
        }
        if(e.keyCode == 37) {
            slow(loading, lines)
            arrowLeft.classList.add('pressed')
        }
        if(e.keyCode == 67) {
            fall(loading, lines)
            spanHidden.classList.add('pressed')
            setTimeout(() => spanHidden.classList.remove('pressed'), 400)
        }
    }

    if(('ontouchstart' in window) || (navigator.maxTouchPoints > 0) || (navigator.msMaxTouchPoints > 0)) {
        spanHidden.innerHTML = "Please don't click here"
    }

    arrowUp.addEventListener('click', e => {
        if(loading.ouch) {
            loading.ouch = false
            reset(loading, lines)
        }
        jump(loading, lines)
    })
    arrowLeft.addEventListener('pointerdown', e => slow(loading, lines))
    arrowRight.addEventListener('pointerdown', e => fast(loading, lines))
    arrowDown.addEventListener('pointerdown', e => down(loading, lines))
    spanHidden.addEventListener('click', e => fall(loading, lines))

    arrowLeft.addEventListener('pointerup', e => !loading.ouch && reset(loading, lines))
    arrowRight.addEventListener('pointerup', e => !loading.ouch && reset(loading, lines))
    arrowDown.addEventListener('pointerup', e => !loading.ouch && reset(loading, lines))
})

const jump = (loading, lines) => {
    if(loading.active) {
        return
    }
    loading.active = true
    loading.count += 1
    if(loading.count > 3) {
        document.querySelector('#keyboard span').classList.remove('hide')
    }
    lines.timeScale(2)
    to(loading, {
        keyframes: [{
            '--skate-x': '-12px',
            duration: .3
        }, {
            '--skate-x': '12px',
            duration: .5
        }, {
            '--skate-x': '0px',
            duration: .5
        }]
    })
    to(loading, {
        keyframes: [{
            '--skate-y': '-32px',
            duration: .4,
            delay: .2
        }, {
            '--skate-y': '0px',
            duration: .2
        }]
    })
    to(loading, {
        keyframes: [{
            duration: .2,
            delay: .2,
            '--arm-front': '40deg',
            '--arm-front-end': '-12deg',
            '--arm-back': '172deg',
            '--arm-back-end': '38deg',
            '--leg-front': '-8deg',
            '--leg-front-end': '102deg',
            '--leg-back': '103deg',
            '--leg-back-end': '-16deg',
            '--board-r': '-40deg',
            '--body-r': '7deg',
            '--body-y': '-90%',
            '--body-x': '-160%',
        }, {
            duration: .2,
            '--arm-front': '24deg',
            '--arm-front-end': '-48deg',
            '--arm-back': '172deg',
            '--arm-back-end': '15deg',
            '--leg-front': '22deg',
            '--leg-front-end': '55deg',
            '--leg-back': '142deg',
            '--leg-back-end': '-58deg',
            '--board-r': '3deg',
            '--body-r': '12deg',
            '--body-y': '-56%',
            '--body-x': '-60%',
        }, {
            duration: .2,
            '--arm-front': '24deg',
            '--arm-front-end': '-48deg',
            '--arm-back': '164deg',
            '--arm-back-end': '-36deg',
            '--leg-front': '-4deg',
            '--leg-front-end': '66deg',
            '--leg-back': '111deg',
            '--leg-back-end': '-36deg',
            '--board-r': '0deg',
            '--body-r': '34deg',
            '--body-y': '-53%',
            '--body-x': '-28%',
        }, {
            '--arm-front': '24deg',
            '--arm-front-end': '-48deg',
            '--arm-back': '164deg',
            '--arm-back-end': '-50deg',
            '--leg-front': '40deg',
            '--leg-front-end': '30deg',
            '--leg-back': '120deg',
            '--leg-back-end': '-36deg',
            '--board-r': '0deg',
            '--body-r': '12deg',
            '--body-y': '-65%',
            '--body-x': '-85%',
            duration: .4,
            onComplete() {
                loading.active = false
                lines.timeScale(1)
            }
        }]
    })
}

const fast = (loading, lines) => {
    if(loading.active) {
        return
    }
    loading.active = true
    loading.count += 1
    if(loading.count > 3) {
        document.querySelector('#keyboard span').classList.remove('hide')
    }
    lines.timeScale(2.5)
    to(loading, {
        '--skate-x': '12px',
        duration: .3
    })
    to(loading, {
        duration: .2,
        '--arm-front': '24deg',
        '--arm-front-end': '-48deg',
        '--arm-back': '164deg',
        '--arm-back-end': '-36deg',
        '--leg-front': '-4deg',
        '--leg-front-end': '66deg',
        '--leg-back': '111deg',
        '--leg-back-end': '-36deg',
        '--board-r': '0deg',
        '--body-r': '34deg',
        '--body-y': '-53%',
        '--body-x': '-28%',
    })
}

const reset = (loading, lines) => {
    if(!loading.active) {
        return
    }
    to(loading, {
        '--skate-x': '0px',
        duration: .3
    })
    to(loading, {
        duration: .2,
        '--arm-front': '24deg',
        '--arm-front-end': '-48deg',
        '--arm-back': '164deg',
        '--arm-back-end': '-50deg',
        '--leg-front': '40deg',
        '--leg-front-end': '30deg',
        '--leg-back': '120deg',
        '--leg-back-end': '-36deg',
        '--board-r': '0deg',
        '--board-x': '0px',
        '--body-r': '12deg',
        '--body-y': '-65%',
        '--body-x': '-85%',
        onComplete() {
            loading.active = false
            lines.play()
            lines.timeScale(1)
        }
    })
}

const slow = (loading, lines) => {
    if(loading.active) {
        return
    }
    loading.active = true
    loading.count += 1
    if(loading.count > 3) {
        document.querySelector('#keyboard span').classList.remove('hide')
    }
    lines.timeScale(.5)
    to(loading, {
        '--skate-x': '-12px',
        duration: .3
    })
    to(loading, {
        duration: .2,
        '--arm-front': '32deg',
        '--arm-front-end': '20deg',
        '--arm-back': '156deg',
        '--arm-back-end': '-22deg',
        '--leg-front': '19deg',
        '--leg-front-end': '74deg',
        '--leg-back': '134deg',
        '--leg-back-end': '-29deg',
        '--board-r': '-15deg',
        '--body-r': '-8deg',
        '--body-y': '-65%',
        '--body-x': '-110%',
    })
}

const down = (loading, lines) => {
    if(loading.active) {
        return
    }
    loading.active = true
    loading.count += 1
    if(loading.count > 3) {
        document.querySelector('#keyboard span').classList.remove('hide')
    }
    to(loading, {
        duration: .2,
        '--arm-front': '-26deg',
        '--arm-front-end': '-58deg',
        '--arm-back': '204deg',
        '--arm-back-end': '60deg',
        '--leg-front': '40deg',
        '--leg-front-end': '80deg',
        '--leg-back': '150deg',
        '--leg-back-end': '-96deg',
        '--body-r': '180deg',
        '--body-y': '-100%',
    })
}

const fall = (loading, lines) => {
    if(loading.active) {
        return
    }
    loading.active = true
    loading.ouch = true
    lines.pause()
    to(loading, {
        duration: .5,
        '--board-x': '60px'
    })
    to(loading, {
        keyframes: [{
            '--board-r': '-40deg',
            duration: .15
        }, {
            '--board-r': '0deg',
            duration: .3
        }]
    })
    to(loading, {
        keyframes: [{
            '--line-top-x': '-100%',
            '--line-bottom-x': '-200%',
            '--body-r': '-8deg',
            '--leg-back-end': '24deg',
            '--leg-back': '60deg',
            '--leg-front-end': '30deg',
            '--leg-front': '10deg',
            '--arm-back-end': '-40deg',
            '--arm-back': '54deg',
            '--arm-front-end': '-28deg',
            '--arm-front': '24deg',
            duration: .2
        }, {
            '--body-x': '-85%',
            '--body-y': '36%',
            '--body-r': '-26deg',
            '--leg-back-end': '24deg',
            '--leg-back': '20deg',
            '--leg-front-end': '30deg',
            '--leg-front': '-10deg',
            '--arm-back-end': '-40deg',
            '--arm-back': '164deg',
            '--arm-front-end': '-28deg',
            '--arm-front': '24deg',
            duration: .2
        }]
    })
}



function showTime() {
    var date = new Date();
    var h = date.getHours(); // 0 - 23
    var m = date.getMinutes(); // 0 - 59
    var s = date.getSeconds(); // 0 - 59

    if (h == 0) {
        h = 24;
    }

    h = (h < 10) ? "0" + h : h;
    m = (m < 10) ? "0" + m : m;
    s = (s < 10) ? "0" + s : s;

    var time = h + ":" + m + ":" + s + " ";
    document.getElementById("saat").innerText = time;
    document.getElementById("saat").textContent = time;

    setTimeout(showTime, 1);

}

showTime();

var aylar = new Array("Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık");
var gunler = new Array("Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi");
function tarih() {
    var now = new Date();
    var yil = now.getFullYear();
    var ay = now.getMonth();
    var gun = now.getDate();
    var haftagun = now.getDay();
    var now = new Date();
    var saat = now.getHours();
    var dakika = now.getMinutes();
    saat = sifirekle(saat);
    dakika = sifirekle(dakika);
    //  var s = getZeroNumber(second);
    document.getElementById("tarih").innerHTML = gun + "&nbsp;" + aylar[ay] + "&nbsp;" + gunler[haftagun];
}
function sifirekle(sayi) {
    if (sayi < 10) {
        return "0" + sayi.toString();
    } else {
        return sayi.toString();
    }
}

tarih();