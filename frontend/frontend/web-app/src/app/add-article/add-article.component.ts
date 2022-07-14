import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../service/ArticleService/article.service';

@Component({
  selector: 'app-add-article',
  templateUrl: './add-article.component.html',
  styleUrls: ['./add-article.component.css']
})
export class AddArticleComponent implements OnInit {

  name: string = ''
  price: number = 0
  ingredients: string = ''

  constructor(private articleService : ArticleService) { }

  ngOnInit(): void {
  }

  save(){
    if(this.name ==='' || this.price === 0 || this.ingredients ==='') return
    const article = {
      id: undefined,
      name: this.name,
      price: this.price,
      ingredients: this.ingredients
    }
    return this.articleService.save(article).subscribe({
      next: res => {
        console.log(res)
      }
    })
  }

}
