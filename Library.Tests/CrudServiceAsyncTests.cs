using Library.Console;

namespace Library.Tests
{
    public class CrudServiceAsyncTests
    {
        private string GetTempFilePath()
        {
            return Path.Combine(Path.GetTempPath(), $"test_books_{Guid.NewGuid()}.json");
        }

        [Fact]
        public async Task CreateAsync_ShouldAddElement()
        {
            var service = new CrudServiceAsync<Book>(GetTempFilePath());
            var book = new Book("Test Book", "Author", 123);

            bool result = await service.CreateAsync(book);
            var fetched = await service.ReadAsync(book.Id);

            Assert.True(result);
            Assert.NotNull(fetched);
            Assert.Equal("Test Book", fetched.Title);
        }

        [Fact]
        public async Task ReadAllAsync_ShouldReturnAll()
        {
            var service = new CrudServiceAsync<Book>(GetTempFilePath());
            var book1 = new Book("A", "B", 100);
            var book2 = new Book("C", "D", 200);

            await service.CreateAsync(book1);
            await service.CreateAsync(book2);

            var all = (await service.ReadAllAsync()).ToList();

            Assert.Equal(2, all.Count);
        }

        [Fact]
        public async Task UpdateAsync_ShouldModifyElement()
        {
            var service = new CrudServiceAsync<Book>(GetTempFilePath());
            var book = new Book("Original", "Author", 150);

            await service.CreateAsync(book);

            book.Title = "Updated";
            bool result = await service.UpdateAsync(book);
            var updated = await service.ReadAsync(book.Id);

            Assert.True(result);
            Assert.Equal("Updated", updated.Title);
        }

        [Fact]
        public async Task RemoveAsync_ShouldDeleteElement()
        {
            var service = new CrudServiceAsync<Book>(GetTempFilePath());
            var book = new Book("ToDelete", "Author", 99);

            await service.CreateAsync(book);
            bool removed = await service.RemoveAsync(book);
            var result = await service.ReadAsync(book.Id);

            Assert.True(removed);
            Assert.Null(result);
        }

        [Fact]
        public async Task SaveAsync_ShouldCreateFileWithData()
        {
            string path = GetTempFilePath();
            var service = new CrudServiceAsync<Book>(path);
            var book = new Book("SaveTest", "Author", 321);

            await service.CreateAsync(book);
            bool saved = await service.SaveAsync();

            Assert.True(saved);
            Assert.True(File.Exists(path));

            string content = File.ReadAllText(path);
            Assert.Contains("SaveTest", content);
        }
    }
}