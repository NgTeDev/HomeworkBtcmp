using HomeworkBtcmp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkBtcmp.Data
{
    public static class DummyData
    {
        public static void Dummy(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<BookContext>();
            context.Database.Migrate();

            var genres = new List<Genre>()
                        {
                            new Genre {Name="Dünya Klasikleri", Books=
                                new List<Book>(){
                                    new Book {
                                        Title="Suç ve Ceza",
                                        Description="Rodion Romanoviç Raskolnikov adındaki bir gencin işlediği çifte cinayet üzerine yaşadıklarını konu alıyor",
                                        ImageUrl="1.jpg"
                                    },
                                    new Book {
                                        Title="Hamlet",
                                        Description="Danimarka'da geçen oyunda Prens Hamlet'in, kral olan babasını öldürdükten sonra tahta geçen ve annesi Gertrude ile evlenen amcası Claudiustan nasıl intikam aldığını anlatır.",
                                        ImageUrl="2.jpg"
                                    },

                                }
                            },
                            new Genre {Name="Çocuk"},
                            new Genre {Name="Romantik"},
                            new Genre {Name="Çizgi Roman"},
                            new Genre {Name="Bilim Kurgu"}
                        };

            var books = new List<Book>()
                        {
                            new Book {
                                Title="Romeo ve Juliet",
                                Description="Romeo ve Juliet’de birbirinden farklı pek çok toplumda benzerleriyle karşılaşılan trajik bir ilişkiyi, düşman ailelerin çocukları arasında doğan aşkı ele alır.",
                                ImageUrl="3.jpg",
                                Genres = new List<Genre>() {genres[0], genres[2] }
                            },
                            new Book {
                                Title="Othello",
                                Description="Shakespeare, Othello’da her çağda geçerli olan trajik bir durumu, saf dürüstlüğün, yalan ve düzen dünyasına yenilişini, yazgıların birbirinden ayrılıp birbiriyle karşılaştığı labirentler içinde aktarır",
                                ImageUrl="4.jpg",
                                Genres = new List<Genre>() {genres[0],genres[2] }
                            },
                            new Book {
                                Title="Kral Şakir",
                                Description="Selam arkadaşlar, ben Şakir. Hepinizin bildiği şekilde nam-ı diğer Kral Şakir.Bu kez de bir çizgi roman albümüyle karşınızdayım.Çılgın ve bir o kadar da komik ailemle yaşadığımızmaceraları çizgi roman olarak bu albümde topladık.",
                                ImageUrl="5.jpg",
                                Genres = new List<Genre>() {genres[1], genres[3] }
                            },
                                new Book {
                                Title="Tenet",
                                Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                                ImageUrl="4.jpg",
                                Genres = new List<Genre>() {genres[0], genres[1] }
                            },
                            new Book {
                                Title="The Amazing Spider",
                                Description="Radyasyon ile ilgili bir gösteriye seyirci olarak katılan lise öğrencisi Peter Parker, yanlışlıkla radyasyona maruz kalan bir örümcek tarafından ısırılır.",
                                ImageUrl="6.jpg",
                                Genres = new List<Genre>() {genres[2], genres[4] }
                            },
                            new Book {
                                Title="Hard Kill",
                                Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                                ImageUrl="1.jpg",
                                Genres = new List<Genre>() {genres[1], genres[2] }
                            }
                        };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }

                if (context.Books.Count() == 0)
                {
                    context.Books.AddRange(books);
                }

                context.SaveChanges();
            }

        }
    }
}
