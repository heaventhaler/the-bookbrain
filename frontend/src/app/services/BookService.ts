import { inject, Injectable, signal } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { catchError, Observable, tap } from "rxjs";
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
    return this.http.post<Book>(`${apiUrl}/books`, newBook).pipe(
      tap((createdBook) => {
        this.booksSignal.update((books) => [...books, createdBook]);
      }),
      catchError((error) => {
        throw error;
      }),
    );
  }

  getById(bookId: number) {
    this.http.get<Book>(`${apiUrl}/books/${bookId}`).subscribe((book) => {
      this.bookSignal.set(book);
    });
  }
}
