class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { "picture": 200, "photo": 50, "item": 250 };
        this.listOfArticles = [];
        this.guests = [];
    }
    addArticle(articleModel, articleName, quantity) {
        if (!this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())) {
            throw new Error("This article model is not included in this gallery!");
        }
        else if (this.listOfArticles.some(x => x.articleName == articleName && x.articleModel == articleModel.toLowerCase())) {
            this.listOfArticles.find(x => x.articleName == articleName && x.articleModel == articleModel.toLowerCase()).quantity += quantity;

        }
        else {
            articleModel = articleModel.toLowerCase();
            this.listOfArticles.push({ articleModel, articleName, quantity });

        }
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.some(x => x.guestName == guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }
        else {
            const personalities = { "Vip": 500, "Middle": 250 };
            let points;
            if (personalities.hasOwnProperty(personality)) {
                points = personalities[personality];
            }
            else {
                points = 50;
            }
            this.guests.push({ guestName, points, purchaseArticle: 0 });
            return `You have successfully invited ${guestName}!`;
        }
    }
    buyArticle(articleModel, articleName, guestName) {
        if (!this.listOfArticles.some(x => x.articleName == articleName) || this.listOfArticles.find(x => x.articleName == articleName).articleModel != articleModel) {
            throw new Error("This article is not found.");
        }
        else if (this.listOfArticles.find(x => x.articleName == articleName).quantity == 0) {
            return `The ${articleName} is not available.`;
        }
        else if (!this.guests.some(x => x.guestName == guestName)) {
            return "This guest is not invited.";
        }
        else {
            const currentGuest = this.guests.find(x => x.guestName == guestName);
            const currentArticle = this.listOfArticles.find(x => x.articleName == articleName);
            if (currentGuest.points < this.possibleArticles[currentArticle.articleModel]) {
                return "You need to more points to purchase the article.";
            }
            else {
                currentGuest.points -= this.possibleArticles[currentArticle.articleModel];
                currentArticle.quantity--;
                currentGuest.purchaseArticle++;
                return `${guestName} successfully purchased the article worth ${this.possibleArticles[currentArticle.articleModel]} points.`;
            }
        }
    }

    showGalleryInfo(criteria) {
        let output = "";
        if (criteria == "article") {
            output = "Articles information:";
            this.listOfArticles.forEach(article => {
                output += `\n${article.articleModel} - ${article.articleName} - ${article.quantity}`;
            });
        }
        else if (criteria == "guest") {
            output = "Guests information:";
            this.guests.forEach(guest => {
                output += `\n${guest.guestName} - ${guest.purchaseArticle}`;
            });
        }
        return output;
    }
}



