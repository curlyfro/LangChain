﻿using LangChain.DocumentLoaders;

namespace LangChain.DocumentLoaders.IntegrationTests;

[TestFixture]
public class Tests
{
    [Test]
    public async Task FileSample1MbDocx()
    {
        var loader = new WordLoader();
        var documents = await loader.LoadAsync(DataSource.FromStream(H.Resources.filesample_1MB_docx.AsStream()));

        documents.Should().NotBeEmpty();

        // check text from paragraph 1
        documents.First().PageContent.Should().Contain("Lorem ipsum ");

        // check text from paragraph 2
        documents.Skip(1).First().PageContent.Should().Contain("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac faucibus odio. ");
    }
}