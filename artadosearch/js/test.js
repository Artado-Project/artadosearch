document.addEventListener('DOMContentLoaded', () => {
    const draggables = [];

    // Read the "adjustments_moveit" cookie and position the elements
    const cookieValue = getCookie('adjustments_moveit');
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
        const objects = document.querySelectorAll('*');

        for (const draggable of objects) {
            if (draggable.className != "middle" && draggable.id != "bdy1" && draggable.tagName != "HTML" && draggable.tagName != "FORM") {
                console.log(draggable.tagName);
                draggable.addEventListener('mousedown', e => {
                    selectedElement = draggable;
                    const offsetX = e.clientX - draggable.getBoundingClientRect().left;
                    const offsetY = e.clientY - draggable.getBoundingClientRect().top;

                    document.addEventListener('mousemove', onMouseMove);
                    document.addEventListener('mouseup', onMouseUp);

                    function onMouseMove(e) {
                        const x = e.clientX - offsetX;
                        const y = e.clientY - offsetY;
                        draggable.style.left = x + 'px';
                        draggable.style.top = y + 'px';
                    }

                    function onMouseUp() {
                        document.removeEventListener('mousemove', onMouseMove);
                        document.removeEventListener('mouseup', onMouseUp);
                    }
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
                        draggable.remove();
                    });

                    document.addEventListener('click', removeDeleteButton);
                });

                draggables.push(draggable);
            }
        };
    }

    function removeDeleteButton() {
        const deleteButtons = document.querySelectorAll('.delete-button');
        deleteButtons.forEach(button => {
            button.remove();
        });
        document.removeEventListener('click', removeDeleteButton);
    }

    const saveButton = document.createElement('button');
    saveButton.id = 'save-button';
    saveButton.innerText = 'Save Adjustments';
    saveButton.style.position = 'fixed';
    saveButton.style.bottom = '10px';
    saveButton.style.right = '10px';
    saveButton.style.padding = '10px';
    saveButton.style.backgroundColor = 'green';
    saveButton.style.color = 'white';
    saveButton.style.border = 'none';
    saveButton.style.borderRadius = '5px';
    saveButton.style.cursor = 'pointer';
    saveButton.addEventListener('click', () => {
        saveButton.addEventListener('click', () => {
            const positions = draggables.map(draggable => {
                return {
                    left: draggable.style.left,
                    top: draggable.style.top,
                    backgroundColor: draggable.style.backgroundColor,
                    width: draggable.style.width,
                    height: draggable.style.height,
                };
            });

            // Convert the positions to JSON and create a cookie
            const jsonPositions = JSON.stringify(positions);
            document.cookie = `adjustments_moveit=${jsonPositions}; expires=Thu, 01 Jan 2099 00:00:00 UTC; path=/`;

            console.log('Saved positions as cookie:', positions);
        });

        document.body.appendChild(saveButton);

        createDraggable();
    })
});