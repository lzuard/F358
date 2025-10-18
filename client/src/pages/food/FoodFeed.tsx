import './FoodFeed.scss'

// interface IFoodItemProps{
//     id: number
// }

function FoodItem() {


    return(
        <div className="food-item">
            <div className="food-item__image-container">
                <h3>Container</h3>
            </div>
            <div className="food-item__info-container">
                <h2>Макароны с сосисками</h2>
                <br/>Сложность: 2/10<br/>Время приготовления: 15 минут
            </div>
        </div>
    )
}

export function FoodFeed() {

    const arr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    const items = arr.map(item => (<FoodItem key={item}/>))
    return(
        <div className="food-feed">
            <div className="content-block">
                <h1>Filters</h1>
            </div>
            {items}
        </div>
    )
}