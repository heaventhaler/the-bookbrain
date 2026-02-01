export interface Book {
  bookId: number;
  title: string;
  author?: string;
  genre: string;
  description?: string;
}

export interface CreateBook {
  title: string;
  author?: string;
}
