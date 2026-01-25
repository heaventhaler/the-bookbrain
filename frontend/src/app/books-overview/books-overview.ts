import { Component, inject, Input, OnInit } from "@angular/core";
import { Book } from "../book";
import { BookService } from "../BookService";
import { CommonModule } from "@angular/common";

@Component({
  selector: "app-books-overview",
  imports: [CommonModule],
  templateUrl: "./books-overview.html",
  styleUrl: "./books-overview.css",
})
export class BooksOverview implements OnInit {
  private bookService = inject(BookService);

  books: Book[] = [];
  isLoading = false;
  error: string | null = null;

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.isLoading = true;
    this.error = null;

    this.bookService.getAll().subscribe({
      next: (books) => {
        this.books = books;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = "Fehler beim Laden der Bücher";
        this.isLoading = false;
        console.error(err);
      },
    });
  }
}
