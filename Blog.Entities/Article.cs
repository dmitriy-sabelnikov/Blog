using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        [Display(Name = "Автор")]
        [Required(ErrorMessage = "Пожалуйста, введите автора")]
        public string Author { get; set; }

        [Display(Name = "Название статьи")]
        [Required(ErrorMessage = "Пожалуйста, введите наименование статьи")]
        public string NameArticle { get; set; }

        [Display(Name = "Текст статьи")]
        [Required(ErrorMessage = "Пожалуйста, введите текст статьи")]
        public string TextArticle { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
