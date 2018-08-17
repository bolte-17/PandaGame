import React, { Component } from "react";
import { axialToPixel } from "../util/HexUtils";

export class IrrigationChannel extends Component {
  render() {
    const { q, r } = this.props;
    const { x, y } = axialToPixel(q, r, 50);
    return <circle cx={x} cy={y} r={50} fill="blue"></circle>
  }
}