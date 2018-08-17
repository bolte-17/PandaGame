import React, { Component } from "react";
import {hexVertices, axialToPixel} from "../util/HexUtils";

export class Hexagon extends Component {
  render() {
    const { q, r, ...rest } = this.props;
    const center = axialToPixel(q, r, 100);
    
    return <polygon class="hex" points={hexVertices(center, 90).map(p => p.x + "," + p.y).join(" ")} {...rest} />
  }
}