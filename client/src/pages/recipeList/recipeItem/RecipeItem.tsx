import './style.scss'
import {useEffect} from "react";

interface IRecipeItemProps {
  name: string
  complexity: number
  complexityLimit: number
  cookingTime: Date
  tags: string[]
  imageId: string
}

export function RecipeItem({
  name,
  complexity,
  complexityLimit,
  cookingTime,
  tags,
  imageId
}: IRecipeItemProps) {
  useEffect(() => {
    console.log(`got image id: ${imageId}`)
  }, [imageId]);
  return(
    <div className="main-container">
      <div className="image-container">
        <img className="image" src="../../../../assets/recipe_default_image.png" alt="Recipe Image" width={200} height={200} />
      </div>
      <div className="info-container">
        <h2>{name}</h2>
        <br/>Сложность: {complexity}/{complexityLimit}
        <br/>Время приготовления: {cookingTime.getTime()}
        <div className="tags-container">
          {tags.map((value, index) => (
            <div key={index} className="tag">
              #{value}
            </div>))}
        </div>
      </div>
    </div>
  )
}