const calculatorScreen = document.querySelector('.calculator-screen')

const updateScreen = (number) => {
    calculatorScreen.value = number
}

const numbers = document.querySelectorAll(".number")

let prevInput = '0'
let calOperator = ''
let currentInp = '0'

const inputNumber = (number) => {
    if (currentInput === '0') {
        currentInput = number
    } else {
        currentInput = currentInput + number
    }
}

numbers.forEach((number) => {
    number.addEventListener("click", (event) => {
        inputNumber(event.target.value)
        updateScreen(currentInput)
    })
})

const operators = document.querySelectorAll(".operator")
const inputOperator = (operator) => {
    prevInput = currentInput
    calculationOperator = operator
    updateScreen(operator)
    currentInput = '0'
}
operators.forEach((operator) => {
    operator.addEventListener("click", (event) => {
        inputOperator(event.target.value)
    })
})

const equalSign = document.querySelector('.equal-sign')

equalSign.addEventListener("click", () => {
    calculate();
    updateScreen(currentInput)
})

const calculate = () => {
    let result = 0
    switch (calculationOperator) {
        case '+':
            result = parseInt(prevInput) + parseInt(currentInput)
            break
        case '-':
            result = parseInt(prevInput) - parseInt(currentInput)
            break
        case '*':
            result = parseInt(prevInput) * parseInt(currentInput)
            break
        case '/':
            result = parseInt(prevInput) / parseInt(currentInput)
            break
        case '%':
            result = (parseInt(prevInput) / 100) * parseInt(currentInput)
            break
        default:
            return
    }
    currentInput = result.toString()
    calculationOperator = ''
}

const clearBtn = document.querySelector('.all-clear')

clearBtn.addEventListener('click', () => {
    console.log('Clear')
})

const clearAll = () => {
    prevInput = '0'
    calculationOperator = ''
    currentInput = '0'
}

clearBtn.addEventListener("click", () => {
    clearAll()
    updateScreen(currentInput)
})