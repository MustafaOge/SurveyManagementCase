using Microsoft.EntityFrameworkCore;
using SurveyManagement.Domain.Entities;
using SurveyManagerCase.Persistence.Context;

namespace SurveyManagement.Persistence.Seeds
{
    public interface ISeedService
    {
        Task SeedAsync();
    }

    public class SeedService : ISeedService
    {
        private readonly AppDbContext _context;

        public SeedService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.Surveys.AnyAsync())
            {
                // Anketleri oluştur
                var surveys = new List<Survey>
                {
                    new Survey
                    {
                        Title = "Müşteri Memnuniyeti Anketi",
                        Description = "Müşteri hizmetlerimizden ne kadar memnun olduğunuzu öğrenmek istiyoruz.",
                        Created = DateTime.UtcNow,
                        CreatedByUser = 1
                    },
                    new Survey
                    {
                        Title = "Çalışan Memnuniyeti Anketi",
                        Description = "Çalışanlarımızın iş tatmini ve iş ortamı hakkındaki görüşlerini öğrenmek istiyoruz.",
                        Created = DateTime.UtcNow,
                        CreatedByUser = 1
                    },
                    new Survey
                    {
                        Title = "Ürün Geri Bildirim Anketi",
                        Description = "Ürünlerimiz hakkında geri bildirimlerinizi toplamak istiyoruz.",
                        Created = DateTime.UtcNow,
                        CreatedByUser = 1
                    },
                    new Survey
                    {
                        Title = "Hizmet Kalitesi Anketi",
                        Description = "Hizmet kalitemiz hakkındaki düşüncelerinizi öğrenmek istiyoruz.",
                        Created = DateTime.UtcNow,
                        CreatedByUser = 1
                    },
                    new Survey
                    {
                        Title = "Eğitim Memnuniyeti Anketi",
                        Description = "Katıldığınız eğitimlerin kalitesini değerlendirmek için anket.",
                        Created = DateTime.UtcNow,
                        CreatedByUser = 1
                    }
                };

                // Soruları ve cevapları oluştur
                var questions = new List<Question>();
                var answers = new List<Answer>();

                var questionTexts = new[]
                {
                    "Hizmetimizi ne kadar beğeniyorsunuz?",
                    "Hizmetlerimizde neyi geliştirmeliyiz?",
                    "Ürünümüzü nasıl değerlendiriyorsunuz?",
                    "Eğitimlerimizi nasıl buluyorsunuz?",
                    "Çalışma ortamımızı nasıl değerlendiriyorsunuz?"
                };

                var answerOptions = new[]
                {
                    "Çok İyi",
                    "İyi",
                    "Orta",
                    "Kötü",
                    "Çok Kötü"
                };

                foreach (var survey in surveys)
                {
                    for (int i = 0; i < questionTexts.Length; i++)
                    {
                        var question = new Question
                        {
                            Survey = survey,
                            Text = $"{questionTexts[i]} - Anket: {survey.Title}",
                            Created = DateTime.UtcNow,
                            CreatedByUser = 1
                        };

                        var questionAnswers = answerOptions.Select(a => new Answer
                        {
                            Question = question,
                            Text = a,
                            Created = DateTime.UtcNow,
                            CreatedByUser = 1
                        }).ToList();

                        question.Answers = questionAnswers;
                        questions.Add(question);
                        answers.AddRange(questionAnswers);
                    }

                    survey.Questions = questions.Where(q => q.Survey.Title == survey.Title).ToList();
                }

                _context.Surveys.AddRange(surveys);
                await _context.SaveChangesAsync();
            }
        }
    }
}
