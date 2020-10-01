import React from 'react';
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'

import Logo from '../../assets/image/Capturar.PNG';

export default function Inicial(){
    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px"/></Link>
                </div>
                <div className="barraPesquisa">
                    fmaifvianvi
                </div>
                <div className="meio">
                    <div>
                        Meus anuncios
                    </div>
                </div>
                <div>
                    <Link  class="hihi" to="./Login"><button class="botao">Entrar</button></Link>
                </div>
            </div>
        </div>
    )
}