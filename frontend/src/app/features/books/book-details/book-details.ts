import { Component, effect, inject, input } from "@angular/core";
import { ActivatedRoute, RouterLink } from "@angular/router";
import { Book } from "src/app/services/book";
import { BookService } from "src/app/services/BookService";

@Component({
  selector: "app-book-details",
  imports: [RouterLink],
  templateUrl: "./book-details.html",
  styleUrls: ["./book-details.scss"],
})
export class BookDetails {
  private bookService = inject(BookService);
  private route = inject(ActivatedRoute);
  book = this.bookService.book;

  constructor() {
    effect(() => {
      const bookId = Number(this.route.snapshot.params["id"]);
      this.bookService.getById(bookId);
    });
  }
}
