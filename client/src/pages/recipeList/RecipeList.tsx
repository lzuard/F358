import './style.scss'
import {RecipeItem} from "./recipeItem/RecipeItem.tsx";

// interface IRecipeItemProps{
//     id: number
// }


export function RecipeListPage() {

  const objects = [
    {
      name: "Макароны с сосиками",
      complexity: 1,
      complexityLimit: 10,
      cookingTime: new Date(2025,1,1, 0, 15,0),
      tags: ["Просто", "Вкусно"],
      imageId: "1"
    },
    {
      name: "Макароны с сосиками",
      complexity: 1,
      complexityLimit: 10,
      cookingTime: new Date(2025,1,1, 0, 15,0),
      tags: ["Просто", "Вкусно"],
      imageId: "1"
    },
    {
      name: "Макароны с сосиками",
      complexity: 1,
      complexityLimit: 10,
      cookingTime: new Date(2025,1,1, 0, 15,0),
      tags: ["Просто", "Вкусно"],
      imageId: "1"
    },
    {
      name: "Макароны с сосиками",
      complexity: 1,
      complexityLimit: 10,
      cookingTime: new Date(2025,1,1, 0, 15,0),
      tags: ["Просто", "Вкусно"],
      imageId: "1"
    },
  ]
  const items = objects.map(((item, index) => (
    <RecipeItem key={index} name={item.name} complexity={item.complexity} complexityLimit={item.complexityLimit}
                tags={item.tags} imageId={item.imageId} cookingTime={item.cookingTime}/>)))
  return (
    <div className="container">
      <div className="recipe-feed">
        <div className="content-block">
          <h1>Filters</h1>
        </div>
        {items}
      </div>
    </div>
  )
}