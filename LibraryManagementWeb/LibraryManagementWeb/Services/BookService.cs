﻿using LibraryManagementWeb.Models;
using System;


namespace LibraryManagementWeb.Services;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        var response = await _httpClient.GetAsync("api/Books");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();
    }
}