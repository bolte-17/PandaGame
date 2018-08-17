const sqrt3 = Math.sqrt(3);
export function hexVertices(center, r) {
  return [
    { x: sqrt3 / 2, y: 1 / 2 },
    { x: 0, y: 1 },
    { x: -sqrt3 / 2, y: 1 / 2 },
    { x: -sqrt3 / 2, y: -1 / 2 },
    { x: 0, y: -1 },
    { x: sqrt3 / 2, y: -1 / 2 },
  ].map(p => ({x: center.x + r * p.x, y: center.y + r * p.y}));
}

export function axialToPixel(q, r, gridUnit = 100) {
  return {
    x: gridUnit * (sqrt3 * q + sqrt3 / 2 * r),
    y: gridUnit * (3 / 2 * r)
  };
}