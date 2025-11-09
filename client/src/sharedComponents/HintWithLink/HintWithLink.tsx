import './style.scss'
import {Link} from "react-router-dom";

interface IHintWithLinkProps {
  textBeforeLink?: string | null
  textAfterLink?: string | null
  linkTo: string
  linkToText: string
}

export function HintWithLink({linkTo, linkToText, textBeforeLink = null, textAfterLink = null}: IHintWithLinkProps) {
  return (
    <p className="hint-with-link">
      {textBeforeLink && textBeforeLink + " "}<Link
      to={linkTo}>{linkToText}</Link>{textAfterLink && textAfterLink + " "}
    </p>
  )
}