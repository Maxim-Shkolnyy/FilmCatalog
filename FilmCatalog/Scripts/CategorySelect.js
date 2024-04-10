class ApiController {
    constructor(baseUrl) {
        this.baseUrl = baseUrl;
    }

    async get() {
        const response = await fetch(`${this.baseUrl}`);
        if (!response.ok) {
            throw new Error('Failed to fetch data');
        }
        return await response.json();
    }

    async getById(id) {
        const response = await fetch(`${this.baseUrl}/${id}`);
        if (!response.ok) {
            throw new Error('Failed to fetch data');
        }
        return await response.json();
    }

    async post(data) {
        const response = await fetch(`${this.baseUrl}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        if (!response.ok) {
            throw new Error('Failed to post data');
        }
        return await response.json();
    }

    async put(id, data) {
        const response = await fetch(`${this.baseUrl}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        if (!response.ok) {
            throw new Error('Failed to put data');
        }
        return await response.json();
    }

    async delete(id) {
        const response = await fetch(`${this.baseUrl}/${id}`, {
            method: 'DELETE'
        });
        if (!response.ok) {
            throw new Error('Failed to delete data');
        }
    }
}

const api = new ApiController('api/Default');

api.get()
    .then(data => console.log('GET result:', data))
    .catch(error => console.error('GET error:', error));

api.getById(5)
    .then(data => console.log('GET by id result:', data))
    .catch(error => console.error('GET by id error:', error));

api.post('New value')
    .then(data => console.log('POST result:', data))
    .catch(error => console.error('POST error:', error));

api.put(5, 'Updated value')
    .then(data => console.log('PUT result:', data))
    .catch(error => console.error('PUT error:', error));

api.delete(5)
    .then(() => console.log('DELETE successful'))
    .catch(error => console.error('DELETE error:', error));
