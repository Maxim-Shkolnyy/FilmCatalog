class CategoryManager {
    


    constructor(selectElement, filmId) {
        this.selectElement = selectElement;
        this.filmId = filmId;
    }

    init() {


    }

    displayCategories() {

        const options = {
            method: 'GET',
        };

        fetch("/api/MyCategories/GetCategoriesForFilm", options)
            .then(response => response.json())
            .then((data) => {
            // handle the response
            })
            .catch((error) => {
            // handle the error
            });

        /*

        selectElement.innerHTML = '';

        this.categories.forEach(c => {
            const optionElement = document.createElement('option');

            optionElement.value = category.id;
            optionElement.textContent = category.name;
            selectElement.appendChild(optionElement);
        });
        */
    }


}