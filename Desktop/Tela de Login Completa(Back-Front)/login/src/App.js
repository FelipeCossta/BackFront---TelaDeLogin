import { useState } from "react";
import './styles/global.css';

import { validarEmail, validarPassword } from './utils/function';

function App() {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")

  const [emailErr, setEmailErr] = useState(false);
  const [passwordErr, setPasswordErr] = useState(false);

  const [statusError, setStatusError] = useState(false);
  const [errorMsg, setErrorMsg] = useState("");

  const validar = () => {
    if (!validarEmail.test(email)) {
      setEmailErr(true);
    } else {
      setEmailErr(false);
    }

    if (!validarPassword.test(password)) {
      setPasswordErr(true);
    } else {
      setPasswordErr(false);
    }

    const dados = {
      email: email,
      password: password
    };

    fetch("http://localhost:5000/api/Usuarios/usuario/login", {
      method: "POST",
      headers: {
        "content-type": "application/json",
      },
      body: JSON.stringify(dados)
    })
    .then(res => res.json())
    .then(data => {
      console.log(data);
      if(data){
        setStatusError(true)
        setErrorMsg("Login concluído!")
        setTimeout(() => {
          setStatusError(false);
        }, 2000);
      }else{
        setStatusError(true)
        setErrorMsg("Usuário não cadastrado!")
        setTimeout(() => {
          setStatusError(false);
        }, 2000);
      }
    });
  }

  const criarConta = () => {
    // Verifica se o email e senha são válidos
    if (!isValidEmail(email)) {
      setStatusError(true);
      setErrorMsg("Email inválido!");
      return;
    }
    if (!isValidPassword(password)) {
      setStatusError(true)
      setErrorMsg("Senha inválida!")
      setTimeout(() => {
        setStatusError(false);
      }, 2000);
      return;
    }

    const dados = {
      email: email,
      password: password
    };
    fetch("http://localhost:5000/api/Usuarios", {
      method: "POST",
      headers: {
        "content-type": "application/json"
      },
      body: JSON.stringify(dados)
    })
      .then(resposta => resposta.json())
      .then(data => {
        console.log(data)
        setStatusError(true)
        setErrorMsg("Cadastro concluído!")
        setTimeout(() => {
          setStatusError(false);
        }, 2000);
      })
      .catch(erro => {
        console.log(erro);
        // alert("Erro ao criar conta, coloque email ou senha válidos!");
        setStatusError(true)
        setErrorMsg("Erro ao criar conta, coloque email ou senha válidos!")
      });
  }

  // Função para verificar se o email é válido
  const isValidEmail = (email) => {
    const re = /\S+@\S+\.\S+/;
    return re.test(email);
  }

  // Função para verificar se a senha é válida
  const isValidPassword = (password) => {
    return password.length >= 8;
  }


  return (
    <div className="container">
      <div className="container-login">
        <div className="wrap-login">
          <div className="login-form">

            <span className="login-form-title">Bem vindo!</span>

            <div className="wrap-input">
              <input
                className={email !== "" ? 'has-val input' : 'input'}
                type="text"
                value={email}
                onChange={e => setEmail(e.target.value)}
              />
              <span className="focus-input" data-placeholder="Email"></span>
            </div>
            {emailErr && <p className="alert">Email inválido.</p>}

            <div className="wrap-input">
              <input
                className={password !== "" ? 'has-val input' : 'input'}
                type="password"
                value={password}
                onChange={e => setPassword(e.target.value)}
              />
              <span className="focus-input" data-placeholder="Senha"></span>
            </div>
            {passwordErr && <p className="alert">Senha inválida.</p>}
            {statusError ? <p className="alert">{errorMsg}</p> : ''}

            <div className="container-login-form-btn">
              <button onClick={validar} className="login-form-btn">Entrar</button>
            </div>

            <div className="text-center">
              <span className="txt1">Não possui conta?</span>
              <a className="txt2" href="#" onClick={criarConta}>Criar conta.</a>

            </div>

          </div>
        </div>
      </div>
    </div>
  )
}

export default App;