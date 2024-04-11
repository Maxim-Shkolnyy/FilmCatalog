class CategoryManager {
    


    constructor(selectElement, filmId) {
        this.selectElement = selectElement;
        this.filmId = filmId;
    }

    init() {

        this.displayCategories();
        let cls = this;

        $(this.selectElement).change(() => {
            cls.saveCategories();
        });

    }

    displayCategories() {
        $(this.selectElement).empty();

        fetch("/api/MyCategories/GetCategoriesForFilm?filmId=" + this.filmId, { method: 'GET' })
            .then(response => response.json())
            .then((data) => {
                data.forEach((cat) => {
                    let opts = {
                        value: cat.CategoryId,
                        text: cat.CategoryName

                    };
                    if (cat.Selected) {
                        opts.selected = "selected";
                    }

                    $(this.selectElement).append($('<option>', opts));
                }
                );

            });


    }

    saveCategories() {
        let data = [];

        $(this.selectElement).val().forEach(item => {

            let dataitem = {
                CategoryId: item,
                Selected: true
            }

            data.push(dataitem);
            
        });

        let opts = {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        };

        fetch("/api/MyCategories/SetCategoriesForFilm?filmId=" + this.filmId, opts);
    }


}