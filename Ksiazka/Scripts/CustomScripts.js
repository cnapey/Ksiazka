        $(document).ready(function(e) {
            var ajaxLoaderHtml = '<div class="bookshelf_base"><div class="bookshelf_wrapper"><ul class="books_list"><li class="book_item first"></li><li class="book_item second"></li><li class="book_item third"></li><li class="book_item fourth"></li><li class="book_item fifth"></li><li class="book_item sixth"></li></ul><div class="shelf"></div></div><h2 class="text-center">Ładowanie</h2></div>';
            $('.partialContent').each(function(index, item) {
                $(item).html(ajaxLoaderHtml);
                var widgetUrl = $(item).data('url');
                if (widgetUrl) {
                    $.ajax({
                        url: widgetUrl,
                        type: "GET",
                        cache: false,
                        success: function (data) {
                            $(item).html(data);
                        },
                        error: function () {
                            console.log('Błąd przetwarzania Widgetu. \n' +
                                'URL: ' + widgetUrl);
                            $(item).html('');
                        }
                    });
                } else {$(item).html('');}
            });
        });