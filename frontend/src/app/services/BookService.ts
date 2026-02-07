import { inject, Injectable, signal } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, tap } from "rxjs";
import { Book, CreateBook } from "./book";

export const apiUrl = "http://localhost:5105/api";

@Injectable({
  providedIn: "root",
})
export class BookService {
  private http = inject(HttpClient);

  private booksSignal = signal<Book[]>([]);
  readonly books = this.booksSignal.asReadonly();

  private bookSignal = signal<Book | undefined>(undefined);
  readonly book = this.bookSignal.asReadonly();

  constructor() {
    this.getAll();
  }

  getAll() {
    this.http.get<Book[]>(`${apiUrl}/books`).subscribe((books) => {
      this.booksSignal.set(books);
    });
  }

  createBook(newBook: CreateBook) {
    return this.http.post<CreateBook>(`${apiUrl}/books`, newBook).pipe(
      tap(() => {
        this.getAll();
      }),
    );
  }

  getById(bookId: number) {
    this.http.get<Book>(`${apiUrl}/books/${bookId}`).subscribe((book) => {
      this.bookSignal.set(book);
    });
  }
}
