let panel = document.querySelector(".mainpanel-container");
let tgl_panel = document.querySelector(".mainpanel-toggle") 

function panel_toggle() {
  let isToggled;
  if (panel.classList.contains("active")) {
    isToggled = 1;
    panel.classList.remove("active");
    isToggled = 0;
  } else {
    isToggled = 0;
    panel.classList.add("active");
    isToggled = 1;
  }
}
console.log(tgl_panel)
tgl_panel.addEventListener("click", panel_toggle);