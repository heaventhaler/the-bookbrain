import { Component, effect, inject, Input, OnInit } from "@angular/core";
import { Book } from "../book";
import { BookService } from "../BookService";
import { CommonModule } from "@angular/common";
import { Observable } from "rxjs";

@Component({
  selector: "app-books-overview",
  imports: [CommonModule],
  templateUrl: "./books-overview.html",
  styleUrl: "./books-overview.css",
})
export class BooksOverview {
  books$!: Observable<Book[]>;
  private booksService = inject(BookService);

  constructor() {
    effect(() => {
      this.books$ = this.booksService.getAll();
    });
  }
}
