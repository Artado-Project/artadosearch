document.addEventListener('DOMContentLoaded', () => {
    const draggables = [];

    // Read the "adjustments_moveit" cookie and position the elements
    const cookieValue = getCookie('adjustments');
    if (cookieValue) {
        const positions = JSON.parse(cookieValue);
        positions.forEach((position, index) => {
            const draggable = draggables[index];
            if (draggable) {
                draggable.style.left = position.left;
                draggable.style.top = position.top;
            }
        });
    }

    // Function to get the value of a cookie by name
    function getCookie(name) {
        const value = `; ${document.cookie}`;
        const parts = value.split(`; ${name}=`);
        if (parts.length === 2) return parts.pop().split(';').shift();
    }

    function createDraggable() {
        // Select all elements on the page
        const objects = document.querySelectorAll('.edit');

        for (const draggable of objects) {
            console.log(draggable.id);
            draggable.addEventListener('mousedown', e => {
                selectedElement = draggable;
                const offsetX = e.clientX - draggable.getBoundingClientRect().left;
                const offsetY = e.clientY - draggable.getBoundingClientRect().top;

                function onMouseMove(e) {
                    const x = e.clientX - offsetX;
                    const y = e.clientY - offsetY;
                    draggable.style.position = 'absolute';
                    draggable.style.left = x + 'px';
                    draggable.style.top = y + 'px';
                }

                function onMouseUp() {
                    document.removeEventListener('mousemove', onMouseMove);
                    document.removeEventListener('mouseup', onMouseUp);
                }

                document.addEventListener('mousemove', onMouseMove);
                document.addEventListener('mouseup', onMouseUp);
            });

            draggable.addEventListener('contextmenu', e => {
                e.preventDefault();
                const deleteButton = document.createElement('button');
                deleteButton.innerText = 'X';
                deleteButton.className = 'delete-button';
                deleteButton.style.position = 'absolute';
                deleteButton.style.top = '-15px';
                deleteButton.style.right = '-15px';
                deleteButton.style.backgroundColor = 'red';
                deleteButton.style.color = 'white';
                deleteButton.style.border = 'none';
                deleteButton.style.borderRadius = '50%';
                deleteButton.style.width = '25px';
                deleteButton.style.height = '25px';
                deleteButton.style.cursor = 'pointer';
                draggable.appendChild(deleteButton);
                deleteButton.addEventListener('click', () => {
                    draggable.style.display = 'none';
                });

                document.addEventListener('click', removeDeleteButton);
            });

            draggables.push(draggable);
        };
    }

    function removeDeleteButton() {
        const deleteButtons = document.querySelectorAll('.delete-button');
        deleteButtons.forEach(button => {
            button.remove();
        });
        document.removeEventListener('click', removeDeleteButton);
    }

    const saveButton = document.getElementById('save-settings');
    saveButton.addEventListener('click', () => {
        const positions = draggables.map(draggable => {
            return {
                name: draggable.id,
                left: draggable.style.left,
                top: draggable.style.top,
                backgroundColor: draggable.style.backgroundColor,
                width: draggable.style.width,
                height: draggable.style.height,
                display: draggable.style.display,
                position: draggable.style.position,
            };
        });

        // Convert the positions to JSON and create a cookie
        const jsonPositions = JSON.stringify(positions);
        console.log(jsonPositions);
        document.cookie = `adjustments=${jsonPositions}; expires=Thu, 01 Jan 2099 00:00:00 UTC; path=/`;

        console.log('Saved positions as cookie:', positions);

        // Save background color and text color
        const bgColor = document.body.style.backgroundColor;
        const textColor = document.body.style.color;
        document.cookie = `bgColor=${bgColor}; expires=Thu, 01 Jan 2099 00:00:00 UTC; path=/`;
        document.cookie = `textColor=${textColor}; expires=Thu, 01 Jan 2099 00:00:00 UTC; path=/`;

        window.location.assign('https://www.example.com');
    });

    createDraggable();

    // Color panel functionality
    var backgroundColorInput = document.getElementById('background-color');
    var textColorInput = document.getElementById('text-color');

    backgroundColorInput.addEventListener('input', function () {
        document.body.style.backgroundColor = backgroundColorInput.value;
    });

    textColorInput.addEventListener('input', function () {
        document.body.style.color =  + "!important";
        document.body.style.cssText = 'background-color: ' + backgroundColorInput.value +'; color: ' + textColorInput.value + ' !important;';
    });
});
