import React from "react";
import Markdown from "react-markdown";
import md from '../../../Media/markdown/Contact.md'

export class PageContact extends React.Component {
  constructor(props){
    super(props);
    
    this.state = { input: "" };
  }

  componentDidMount = async () => {
    let r = await fetch(md )
    this.setState({ input: await r.text() });
  }

  render() {
    return (<div>
      <Markdown className="markdown-body">{this.state.input}</Markdown>
    </div>)
  }
}