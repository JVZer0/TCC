import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Home/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';


export default function Home(props){
    const [infos, setInfos] = useState(props.location.state);

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div>
                <div className="barraPesquisa">
                    Barra de pesquisa
                </div>
                <div className="meio"> 
                    <Link  class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>


            <h5>Home</h5>
        </div>
    )
}