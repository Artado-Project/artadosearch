const accordions = document.querySelectorAll(".accordion-container");

for (let index = 0; index < accordions.length; index++) {
  const accordion = {
    header: accordions[index].querySelector(".headerbar"),
    isActive: accordions[index].classList.contains("active"),
    toggle: function() {
      if (!this.isActive) {
        accordions[index].classList.add("active");
        this.isActive = true;
      } else {
        accordions[index].classList.remove("active");
        this.isActive = false;
      }
    }
  };

  accordion.header.addEventListener("click", accordion.toggle);
}