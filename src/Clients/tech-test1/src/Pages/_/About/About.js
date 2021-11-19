import React from "react";
import Markdown from "react-markdown";
import md from '../../../Media/markdown/About.md'

export class PageAbout extends React.Component {

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