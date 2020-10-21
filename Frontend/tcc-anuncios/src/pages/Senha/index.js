import React from 'react';
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Inicial/style.css'
import '../Senha/style.css'

import Logo from '../../assets/image/Capturar.PNG';

export default function Senha(){
    return(
        <div className="in">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>

            <div className="ini">
                <label className="su">Sua senha é:</label>
                <button className="botox1">Fazer login</button>
            </div>
        </div>
    )
}
