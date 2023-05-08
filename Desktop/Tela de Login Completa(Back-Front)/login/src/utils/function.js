export const validarEmail = new RegExp("^[a-zA-Z0-9._:$!%-]+@[a-zA-Z0-9.-]+.[a-zA-Z]$")

export const validarPassword = new RegExp("^(?=.*?[A-Za-z])(?=.*?[0-9]).{6,}$")