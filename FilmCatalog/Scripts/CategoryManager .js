class CategoryManager {
    constructor(categories) {
        this.categories = categories;
    }

    displayCategories(selectElementId) {
        const selectElement = document.getElementById(selectElementId)

        selectElement.innerHTML = '';

        this.categories.forEach(c => {
            const optionElement = document.createElement('option');

            optionElement.value = category.id;
            optionElement.textContent = category.name;
            selectElement.appendChild(optionElement);
        });
    }

    addCategoriesToElement(elementId) {
        const element = document.getElementById(elementId);

        element.innerHTML = '';

        this.categories.forEach(category => {
            const checkboxElement = document.createElement('input');
            checkboxElement.type = 'checkbox';
            checkboxElement.value = category.id;
            checkboxElement.name = 'categories';
            checkboxElement.id = `category_${category.id}`;
            const labelElement = document.createElement('label');
            labelElement.setAttribute('for', `category_${category.id}`);
            labelElement.textContent = category.name;

            element.appendChild(checkboxElement);
            element.appendChild(labelElement);
            element.appendChild(document.createElement('br'));
        });
    }
}