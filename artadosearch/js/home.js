let search_delete = document.getElementById('search-delete')
let search_input = document.getElementById('search-input')
let search_button = document.getElementById('search-button')
let search_results = document.getElementById('search-results')

function show() {
    search_results.hidden = false
    search_delete.hidden = false
    search_input.classList.add('rounded-bl-none')
    search_button.classList.add('rounded-br-none')
}

function hide() {
    search_results.hidden = true
    search_delete.hidden = true
    search_input.classList.remove('rounded-bl-none')
    search_button.classList.remove('rounded-br-none')
}

search_input.addEventListener("keyup", () => {
    if (search_input.value) {
        show()
    } else {
        hide()
    }
});

search_delete.addEventListener("click", () => {
    search_input.value = ''
    hide()
})