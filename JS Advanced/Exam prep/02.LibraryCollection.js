class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }
    addBook(bookName, bookAuthor) {
        if (this.books.length == this.capacity) {
            throw new Error("Not enough space in the collection.");
        }
        else {
            this.books.push({ bookName, bookAuthor, payed: false });
            return `The ${bookName}, with an author ${bookAuthor}, collect.`;


        }
    }

    payBook(bookName) {
        if (!this.books.some(x => x.bookName == bookName)) {
            throw new Error(`${bookName} is not in the collection.`);
        }
        else if (this.books.find(x => x.bookName == bookName).payed == true) {
            throw new Error(`${bookName} has already been paid.`);
        }
        else {
            this.books.find(x => x.bookName == bookName).payed = true;
            return `${bookName} has been successfully paid.`;
        }
    }

    removeBook(bookName) {
        if (!this.books.some(x => x.bookName == bookName)) {
            throw new Error(`The book, you're looking for, is not found.`);
        }
        else if (!this.books.find(x => x.bookName == bookName).payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }
        else {
            this.books.splice(this.books.indexOf(this.books.find(x => x.bookName == bookName)), 1);
            return `${bookName} remove from the collection.`;
        }
    }

    getStatistics(bookAuthor) {
        if (bookAuthor === undefined) {
            let output = `The book collection has ${this.capacity - this.books.length} empty spots left.\n`;
            this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            for (let book of this.books) {
                output += `${book.bookName} == ${book.bookAuthor} - ${book.payed ? "Has Paid" : "Not Paid"}.\n`;
            }
            return output;
        }
        else {
            let authorsBooks = this.books.filter(x => x.bookAuthor == bookAuthor);
            if (authorsBooks.length == 0) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }
            else {
                let output = "";
                for (let book of authorsBooks) {
                    output += `${book.bookName} == ${bookAuthor} - ${book.payed ? "Has Paid" : "Not Paid"}.\n`;
                }
                return output;
            }
        }
    }
}





