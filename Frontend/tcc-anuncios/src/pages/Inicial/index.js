import React from 'react';
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Inicial/style.css'

import Logo from '../../assets/image/Capturar.PNG';

export default function Inicial(){
    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px"/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
                <div>
                    <Link  class="hihi" to="/Login"><button class="botao">Entrar</button></Link>
                </div>
            </div>

            <div className="ko">
                <h1 className="k">Venha fazer parte do time</h1>
                <h3 className="kk">Anuncie suas peças de roupas novas ou usadas aqui no nosso site. Crie uma conta agora</h3>
                <Link className="hihi" to="/Cadastrar"><button class="botao2">Criar Conta</button></Link>
            </div>

            <div className="rodape">
                <div className="tey">
                    <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                </div>
            </div>
        </div>
    )
}
